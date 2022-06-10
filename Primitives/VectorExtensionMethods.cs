using UnityEngine;

namespace WizardsRepublic.Primitives
{
  public static class VectorExtensionMethods
  {
    public static Vector3 GetBarycentricCoordinates(this Vector3 point, Vector3 v0, Vector3 v1, Vector3 v2)
    {
      Vector3 v10 = v1 - v0;
      Vector3 p0 = point - v0;
      Vector3 v21 = v2 - v1;
      Vector3 p1 = point - v1;
      Vector3 v02 = v0 - v2;
      Vector3 p2 = point - v2;
      Vector3 nor = Vector3.Cross(v10, v02);

      Vector3 q = Vector3.Cross(nor, p0);
      float d = 1.0f / Vector3.SqrMagnitude(nor);
      float u = d * Vector3.Dot(q, v02);
      float v = d * Vector3.Dot(q, v10);
      float w = 1.0f - u - v;

      if (u < 0.0)
      {
        w = Mathf.Clamp01(Vector3.Dot(p2, v02) / Vector3.SqrMagnitude(v02));
        u = 0.0f;
        v = 1.0f - w;
      }
      else if (v < 0.0)
      {
        u = Mathf.Clamp01(Vector3.Dot(p0, v10) / Vector3.SqrMagnitude(v10));
        v = 0.0f;
        w = 1.0f - u;
      }
      else if (w < 0.0)
      {
        v = Mathf.Clamp01(Vector3.Dot(p1, v21) / Vector3.SqrMagnitude(v21));
        w = 0.0f;
        u = 1.0f - v;
      }

      return new Vector3(w, u, v);
    }

    public static Vector3 GetProjectedPosition(this Vector3 position, Transform projectionTransform)
    {
      var forward = projectionTransform.forward;

      Plane plane = new Plane(forward, projectionTransform.position);
      return position - forward * plane.GetDistanceToPoint(position);
    }
    
    // https://www.shadertoy.com/view/ttfGWl by Inigo Quilez
    public static Vector3 GetClosestPointToTriangle(this Vector3 p, Vector3 v0, Vector3 v1, Vector3 v2, out Vector3 barycentricCoordinates)
    {
      barycentricCoordinates = p.GetBarycentricCoordinates(v0, v1, v2);
      return barycentricCoordinates.z * v1 + barycentricCoordinates.y * v2 + barycentricCoordinates.x * v0;
    }
  }
}